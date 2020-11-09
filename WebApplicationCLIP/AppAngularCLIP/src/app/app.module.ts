import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginBox} from './components/login-box/login.component';
import { LoginService } from './services/login.service';

import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginBox
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [[LoginService]],
  bootstrap: [AppComponent]
})
export class AppModule { }
