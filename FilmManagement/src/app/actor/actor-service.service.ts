import { Injectable } from '@angular/core';
import { Actor } from './classActor';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ActorServiceService {
  // Port
  public Port = 51215;
  // ulr
  public ActorRoute: string = 'http://localhost:' + this.Port.toString();

  // ----------------------URI-------------------------------------------------//
  public getAllActor = '/api/Actor/GetAllActor';
  // get actor by id ,Uri
  public getActorbyID = `${this.ActorRoute}/api/Actor/GetActorById`;
  // post actor uri
  public PostActorToAPI = `${this.ActorRoute}/api/Actor/AddActor`;
  // put actor uri
  public PutActorToAPI = `${this.ActorRoute}/api/Actor/UpdateActor`;
  // Delete actor uri
  public DeleteActorToAPI = `${this.ActorRoute}/api/Actor/DeleteActor`;
  // GET : change status of actor
  public GetChangeStatusActor = `${this.ActorRoute}/api/Actor/EditStatusById`;
  // --------------------------------------------------------------------------//

  // GET Method get all information of actor
  getActor(): Observable<Array<Actor>> {
    return this.http.get<Array<Actor>>(this.ActorRoute + this.getAllActor);
  }

  // GET Method get a actor follow the id of actor
  getActorById(id: number): Observable<Actor> {
    return this.http.get<Actor>(`${this.getActorbyID}/${id}`);
  }

 // DELETE method remove a actor(delete a actor from database)
  removeActor(id: number): Observable<Actor> {
    return this.http.delete<Actor>(`${this.DeleteActorToAPI}/${id}`);
  }

  // POST method post a actor
  AddActorToAPI(actor: Actor): Observable<Actor> {
    // log to check paramater
    console.log(actor);
    return this.http.post<Actor>(this.PostActorToAPI, actor);
  }

  // PUT Method help you update a actor
  UpdateActor(id: number , actor: Actor): Observable<Actor> {
    // log check paramater
    console.log(actor);
    return this.http.put<Actor>(`${this.PutActorToAPI}/${id}`, actor);
  }

  // PUT this method help you change the status's actor
  ChangeStatusActor(id: number): Observable<Actor> {
    // log check paramater
    console.log(id);
    return this.http.get<Actor>(`${this.GetChangeStatusActor}/${id}`);
  }

  // contructor
  constructor(private http: HttpClient) { }
}
