import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginBox } from './components/login-box/login.component';
import { LoginService } from './services/login.service';

import { FormsModule } from '@angular/forms';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomePageComponent } from './components/home-page/home-page.component';

import { RouterModule } from '@angular/router';

import { HttpClientModule } from '@angular/common/http';
import { SignupPageComponent } from './components/signup-page/signup-page.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginBox,
    NavBarComponent,
    HomePageComponent,
    SignupPageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'signup', component: SignupPageComponent },
      { path: '', component: HomePageComponent },
      { path: 'login', component: LoginBox }
    ])
  ],
  providers: [[LoginService]],
  bootstrap: [AppComponent]
})
export class AppModule { }
