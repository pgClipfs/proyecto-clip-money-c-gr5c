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
import { PaginaPrincipalComponent } from './components/pagina-principal/pagina-principal.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginBox,
    NavBarComponent,
    HomePageComponent,
    PaginaPrincipalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomePageComponent },
      { path: 'login', component: LoginBox },
      { path: 'principal', component: PaginaPrincipalComponent}
    ])
  ],
  providers: [[LoginService]],
  bootstrap: [AppComponent]
})
export class AppModule { }
