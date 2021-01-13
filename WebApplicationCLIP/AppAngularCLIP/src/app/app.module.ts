import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginBox } from './components/login-box/login.component';
import { LoginService } from './services/login.service';
import { SignupService } from './services/signup.service';

import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomePageComponent } from './components/home-page/home-page.component';

import { RouterModule } from '@angular/router';

import { HttpClientModule } from '@angular/common/http';
import { SignupPageComponent } from './components/signup-page/signup-page.component';
import { PaginaPrincipalComponent } from './components/pagina-principal/pagina-principal.component';
import { RegistroExitosoComponent } from './components/registro-exitoso/registro-exitoso.component';
import { SidebarModule } from 'ng-sidebar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PantallaIngresoEgresoDineroComponent } from './components/pantalla-ingreso-egreso-dinero/pantalla-ingreso-egreso-dinero.component';
import { PantallaTransferenciaComponent } from './components/pantalla-transferencia/pantalla-transferencia.component';
import { OperacionesComponent } from './components/operaciones/operaciones.component';
import { PantallaExitoComponent } from './components/pantalla-exito/pantalla-exito.component';
import { PantallaFalloComponent } from './components/pantalla-fallo/pantalla-fallo.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginBox,
    NavBarComponent,
    HomePageComponent,
    SignupPageComponent,
    PaginaPrincipalComponent,
    RegistroExitosoComponent,
    PantallaIngresoEgresoDineroComponent,
    PantallaTransferenciaComponent,
    OperacionesComponent,
    PantallaExitoComponent,
    PantallaFalloComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'signup', component: SignupPageComponent },
      { path: 'registroExitoso', component: RegistroExitosoComponent },
      { path: '', component: HomePageComponent },
      { path: 'login', component: LoginBox },
      { path: 'exito', component: PantallaExitoComponent },
      { path: 'transferencia', component: PantallaTransferenciaComponent},
      { path: 'home', component: SidebarComponent},

    ]),
    NgbModule
  ],
  providers: [[LoginService],[SignupService]],
  bootstrap: [AppComponent]
})
export class AppModule { }
