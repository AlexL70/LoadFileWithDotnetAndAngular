using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LoadFiles.Core;
using LoadFiles.Core.Models;
using LoadFiles.Core.Models.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MFile=LoadFiles.Core.Models.File;
using SysFile=System.IO.File;

namespace LoadFiles.Controllers {
    [Route ("api/[controller]")]
    public class FilesController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostEnv;

        private string _uploadsFolderPath => Path.Combine (_hostEnv.WebRootPath, $"uploadedFiles");

        public FilesController (
            IUnitOfWork unitOfWork,
            IFileRepository repository,
            IMapper mapper,
            IHostingEnvironment hostEnv
        ) {
            this._repository = repository;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost][Route("{userId}")]
        public async Task<IActionResult> AddFile(int userId, IFormFile file) {
            var (path, size) = await SaveAndGetRelativePath(userId, file);

            var newFile = new MFile { 
                UserId = userId,
                Name = file.FileName,
                Size = size,
                UploadPath = path,
                UploadDate = DateTime.UtcNow 
            };

            await _repository.Add(newFile);
            await _unitOfWork.Complete();

            var result = _mapper.Map<MFile, FileResource>(newFile);

            return Ok(result);
        }

        private async Task<Tuple<string, long>> SaveAndGetRelativePath(int userId, IFormFile file) {
            var path = Path.Combine (_uploadsFolderPath, String.Format("{0,8:D8}", userId));
            if (!Directory.Exists (path))
                Directory.CreateDirectory (path);
            var filePath = Path.Combine (path, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            
            return new Tuple<string, long>(
                Path.GetRelativePath(_hostEnv.WebRootPath, filePath),
                file.Length);
        }
    }
}