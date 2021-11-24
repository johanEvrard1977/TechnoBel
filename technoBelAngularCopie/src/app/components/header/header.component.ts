import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NbAuthService } from '@nebular/auth';
import { User } from 'src/app/interfaces/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  user!: User | null;
  
  constructor(private authService: NbAuthService, private router: Router) {

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

  onSignOut()
  {
    this.authService.logout('email').subscribe((result) => {
      this.router.navigateByUrl('/auth/login');
    })
  }
}
