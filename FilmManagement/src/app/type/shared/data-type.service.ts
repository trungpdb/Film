import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Type } from '../shared/type.model';

@Injectable({
  providedIn: 'root'
})
export class DataTypeService {

  constructor(private http: HttpClient) { }

  // localhost API
  public UrlAPI = 'http://localhost:51215/api/Types/';
  public Get    = this.UrlAPI + 'GetTypes';
  public GetID  = this.UrlAPI + 'GetType';
  public Post   = this.UrlAPI + 'InsertType';
  public Put    = this.UrlAPI + 'UpdateType';
  public Delete = this.UrlAPI + 'DeleteType';

  // GET
  getData(): Observable<Array<Type>> {
    return this.http.get<Array<Type>>(this.Get);
  }

  // GET ID
  getIdData(id: number): Observable<Type> {
    return this.http.get<Type>(this.GetID + `/${id}`);
  }

  // POST
  postData(type: Type): Observable<Type> {
    return this.http.post<Type>(this.Post, type);
  }

  // DELETE
  deleteData(id: number): Observable<Type> {
    return this.http.delete<Type>(this.Delete + `/${id}`);
  }

  // PUT
  putData(id: number, type: Type): Observable<Type> {
    return this.http.put<Type>(this.Put + `/${id}`, type);
  }

}
