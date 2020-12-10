import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar-lateral',
  templateUrl: './navbar-lateral.component.html',
  styleUrls: ['./navbar-lateral.component.css']
})
export class NavbarLateralComponent implements OnInit {

  constructor() { }

  nombreUsuario = 'juancuello98';
  opened = false;
  abrirSideBar(){
    this.opened = !this.opened;
  }

  ngOnInit(): void {
  }

}
