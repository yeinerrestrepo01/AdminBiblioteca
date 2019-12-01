import { Component, OnInit } from '@angular/core';
import { AuthService } from './shared/services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'WebAdminBiblioteca';

  constructor(private auth: AuthService){}

  ngOnInit() {
    this.getToken();
  }

  getToken()
  {
    this.auth.RequestToken();
  }
}
