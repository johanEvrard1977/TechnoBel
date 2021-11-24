import { Component } from '@angular/core';
import { NbAuthService } from '@nebular/auth';
import { NbMenuItem } from '@nebular/theme';
import { User } from './interfaces/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  user!: User | null;

  baseMenu: NbMenuItem[] = [
    { link: 'home', title: 'Acceuil', icon: 'home' }
  ];

  MenuAdmin: NbMenuItem[] = [
    { link: 'home', title: 'Acceuil', icon: 'home' },
    { link: 'profile', title: 'Profile', icon: 'profile' }
  ];

  constructor(private authService: NbAuthService) {

    this.authService.onTokenChange()
      .subscribe((token) => {

        if (token.isValid()) {
          this.user = token.getPayload(); // here we receive a payload from the token and assigns it to our `user` variable   
        }
        else {
          this.user = null;
        }
      });
  }
}
