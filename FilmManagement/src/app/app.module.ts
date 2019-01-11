import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';

import { DataService } from './data.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { DirectorComponent } from './director/director.component';
import { FilmComponent } from './film/film.component';
import { TypeComponent } from './type/type.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

import { ActorComponent } from 'src/app/actor/actor.component';
import { UserManagementModule } from './user-management/user-management.module';
import { DatePipe } from '@angular/common';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    ActorComponent,
    FilmComponent,
    HomeComponent,
    LoginComponent,
    ActorComponent,
    DirectorComponent,
    FilmComponent,
    HomeComponent,
    LoginComponent,
    TypeComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    UserManagementModule,
    NgxPaginationModule,
    HttpModule,
    HttpClientModule
  ],

  providers: [DataService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

