using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LoadFiles.Core;
using LoadFiles.Core.Models;
using LoadFiles.Core.Models.Resources;
using LoadFiles.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MFile=LoadFiles.Core.Models.File;
using SysFile=System.IO.File;

namespace LoadFiles.Controllers {
    [Route ("api/[controller]")]
    public class FilesController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileRepository _repository;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostEnv;
        private readonly FileLoading _flSettings;

        private string _uploadsFolderPath => Path.Combine (_hostEnv.WebRootPath, $"uploadedFiles");

        public FilesController (
            IUnitOfWork unitOfWork,
            IFileRepository repository,
            IUserRepository userRepo,
            IMapper mapper,
            IHostingEnvironment hostEnv,
            IOptionsSnapshot<FileLoading> flOptions
        ) {
            this._repository = repository;
            this._userRepo = userRepo;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
            this._flSettings = flOptions.Value;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost][Route("{userId}")]
        [ProducesResponseType(typeof(FileResource), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddFile(int userId, IFormFile file) {
            var user = await _userRepo.Get(userId);

            if (user == null)
                return NotFound($"User with id = {userId} not found.");
            if (file is null)
                return BadRequest("Null file.");
            if (file.Length == 0)
                return BadRequest("Empty file.");
            if(_flSettings.MaxBytes < file.Length)
                return BadRequest($"File is too long. Max allowed length is {_flSettings.MaxBytes}.");
            if (!_flSettings.isAcceptedFileType(file.FileName))
                return BadRequest($"This file type is not allowed. Allowed extensions are: {_flSettings.AcctptedFileTypesAsString}");

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
            result.User = _mapper.Map<User, UserResource>(user);

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