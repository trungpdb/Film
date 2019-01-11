import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataFilmService {

  // port mặc định
  private BasePort = '51215';
  // đương dẫn mặc định
  private BaseUrl = 'http://localhost:' + this.BasePort + '/api/film/';

  private BaseToken = 'http://localhost:' + this.BasePort + '/api/login/check';
  // API
  private UrlAPI = this.BaseUrl + 'GetAllListFilm/';
  private UrlAPI_Add = this.BaseUrl + 'AddNewFilm/';
  private UrlAPI_Del = this.BaseUrl + 'DeleteFilm/';
  private UrlAPI_FindID = this.BaseUrl + 'FindFilmByID/';
  private UrlAPI_Edit = this.BaseUrl + 'EditFilm/';
  private UrlAPI_EditStatut = this.BaseUrl + 'EditStatustFilm/';

  // hàm dựng
  constructor(private http: HttpClient) { }

  // lấy dữ liệu từ server
  getData(): Observable<any> {
    return this.http.get(this.UrlAPI);
  }

  sendToken(params): Observable<any> {
    return this.http.post(this.BaseToken, params);
  }

  // thêm phim mới
  addFilm(params): Observable<any> {
    return this.http.post(this.UrlAPI_Add, params);
  }

  // xóa phim
  removeFilm(i): Observable<any> {
    return this.http.get(this.UrlAPI_Del + i);
  }

  // cập nhật trạng thái
  updateStatusFilm(i): Observable<any> {
    return this.http.get(this.UrlAPI_EditStatut + i);
  }

  // tìm phim theo ID
  findEditFilm(id): Observable<any> {
    return this.http.get(this.UrlAPI_FindID + id);
  }

  // chỉnh sữa phim
  editFilm(params): Observable<any> {
    return this.http.post(this.UrlAPI_Edit, params);
  }
}
