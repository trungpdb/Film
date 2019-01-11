import { Director } from './classDirector';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class DataDirectorService {

 // Port default
 private DefaultPort = '51215';

 // Default path
 private DefaultUrl = 'http://localhost:' + this.DefaultPort + '/api/director/';

 // API
 private UrlAPI = this.DefaultUrl + 'getalldirectors/';
 private UrlAPI_Add = this.DefaultUrl + 'AddNewDirector/';
 private UrlAPI_Del = this.DefaultUrl + 'RemoveDirectorByID/';
 private UrlAPI_FindID = this.DefaultUrl + 'FindDirectorByID/';
 private UrlAPI_Edit = this.DefaultUrl + 'EditDirector/';

 // Constructer
 constructor(private http: HttpClient) { }

 // Get data from server
 getData(): Observable<any> {
   // return this.http.get(this.UrlAPI);
   return this.http.get(this.UrlAPI);
 }

 // Add new director
 addDirector(params): Observable<any> {
   return this.http.post(this.UrlAPI_Add, params);
 }

 // Remove director
 removeDirector(i): Observable<any> {
   return this.http.get(this.UrlAPI_Del + i);
 }

 // Edit director
 findEditDirector(params): Observable<any> {
   return this.http.post(this.UrlAPI_Edit, params);
 }
}
