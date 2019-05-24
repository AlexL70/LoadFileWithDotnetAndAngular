import { KeyValuePair } from './KeyValuePair';

export interface File extends KeyValuePair {
  size: number;
  uploadDate: string;
  user: KeyValuePair;
}
