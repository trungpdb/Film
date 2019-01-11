import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { Actor } from './classActor';
import { ActorServiceService } from './actor-service.service';
import { _sanitizeHtml } from '@angular/core/src/sanitization/html_sanitizer';
import { _sanitizeUrl } from '@angular/core/src/sanitization/url_sanitizer';
import { NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
@NgModule({
  declarations: [
    ActorServiceService
  ],
  imports: [
    NgxPaginationModule,
    NgbDatepicker]
})

@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.scss']
})
export class ActorComponent implements OnInit {

  // button,... name
  nameBtn = 'Thêm';
  // check Validate name
  checkName = false;
  // regular expression(no special characters)
   rgxSpecialChar = new RegExp('^[\^\;!@#$%^&*\(\\)\\{\\}\\+\\-\_+:|<>?~\\\\/\\[\.,\'\\"\\]\\`\]*$');
  // property
  // list actor
  lstActor = [];

  tActor: Actor;
  rowCount = 5;

  actorID: number;
  Name: string;
  Image: string;
  ImageName: string;
  Gender: boolean;
  Birthday: string;
  Describe: string;
  status: boolean;

  // error message
  errorMessage = '';

  // current time for datatimepicker
  today: string = new Date().toString();
  // contructor
  constructor(private Actordata: ActorServiceService, private _sanitizer: DomSanitizer) { }

  /**
  * Creating a actor
  */
  CreateActor(name: string, img: string, gender: boolean, birthday: string, Describe: string, Status: boolean): Actor {
    const actor = new Actor();
    actor.ActorName = name;
    actor.Img = img;
    actor.Birthday = birthday;
    actor.Gender = gender;
    actor.Describe = Describe;
    actor.Status = Status;
    return actor;
  }

  // Set default data binding
  SetDefaultDataBinding() {
    this.tActor = null;
    this.Name = '';
    this.Gender = true;
    this.Describe = '';
    this.ImageName = '';
    this.Image = '';
    this.Birthday = '';
    this.status = true;
  }

  // position pagination ----------------
  // if (p == null) {
  //   p = 1;
  // }
  // i = i + (this.rowCount * (p - 1));
  // ------------------------------------

  /**
   * Remove the Actor
   */
  RemoveActor() {
    // log to check id actor
    console.log(this.actorID);
    this.Actordata.removeActor(this.actorID).subscribe(
      res => { this.getAllActor();
      console.log('xóa ok rồi nè senpai <3');
      });
  }

  // add new  actor
  AddActor() {
    if (!this.checkName) {
      console.log(this.Name);
      // Create actor
      this.tActor = this.CreateActor(this.Name, this.Image, this.Gender, this.Birthday, this.Describe, this.status);
      // console.log(this.tActor);
      if (this.tActor != null) {
        // Subscribe
        this.Actordata.AddActorToAPI(this.tActor).subscribe(data => this.getAllActor());
      }
    } else {
        // set default value
        this.SetDefaultDataBinding();
        alert('Oops !Tên nhập vào không hợp lệ !');
    }
  }
  // Set actor id
  SetActorIDFromModal(id: number) {
    // console.log("actor id: "+ id);
    this.actorID = id;
  }

  // Set actor entity anad image name
  SetActorFromModal(actor: Actor, nameImg: string) {
    this.tActor = actor;
    this.Name = actor.ActorName;
    this.Image = actor.Img;
    this.ImageName = nameImg;
    this.Gender = actor.Gender;
    this.Birthday = actor.Birthday;
    this.Describe = actor.Describe;
    this.status = actor.Status;
  }
  // Change
  ChangeStatus(actor: Actor) {
    this.SetActorIDFromModal(actor.ActorID);
    console.log(this.actorID);
    this.Actordata.ChangeStatusActor(actor.ActorID).subscribe(
      res => {console.log('Change status sucess');
      this.getAllActor(); });
  }

  // Modify a Actor at position i
  ModifyActor() {
    if (!this.checkName) {
      this.tActor = new Actor();
      // create actor
      this.tActor = this.CreateActor(this.Name, this.Image, this.Gender, this.Birthday, this.Describe, this.status);
      // console.log(this.actorID); // log to check ID is right :)
      // update actor via service
      this.Actordata.UpdateActor(this.actorID, this.tActor).subscribe(res => this.getAllActor());
      // set default value
      this.SetDefaultDataBinding();
    } else {
      this.Name = '';
      alert('Oops !Tên nhập vào không hợp lệ !');
    }
  }

  getAllActor() {
    this.Actordata.getActor().subscribe(res => {
      this.lstActor = res;
      console.log(this.lstActor);
    });
  }

  // get data image and set text to input tag via ID attribute
  getImageData(event: any, id: string) {
    this.ImageName = '';
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();

      reader.onload = (Myevent: any) => {
        this.Image = Myevent.target.result;
      };
      reader.readAsDataURL(event.target.files[0]);
      // get data img
      this.Image = <string>this._sanitizer.bypassSecurityTrustResourceUrl(event.target.result);
      // set text file name add modal
      this.ImageName = event.target.files[0].name;
      // (<HTMLInputElement>document.getElementById(id)).value = this.ImageName;
    }
  }

  // -----------------------Lifecycle Hooks------------------------ //
  // tslint:disable-next-line:use-life-cycle-interface
  ngDoCheck() {
  // Called every time that the input properties of a component or a directive are checked.
  // Use it to extend change detection by performing a custom check.
  // Add 'implements DoCheck' to the class.
  // console.log(!this.rgxSpecialChar.exec(this.Name));
  if (this.Name === '' || !this.rgxSpecialChar.test(this.Name)) {
    this.errorMessage = 'Tên diễn viên có kí tự đặc biệt hoặc không được rỗng';
    this.checkName = true; // have special character => show
  } else {
    this.errorMessage = ' ';
    this.checkName = false;
  }
}

  ngOnInit() {
    this.getAllActor();
  }

}
