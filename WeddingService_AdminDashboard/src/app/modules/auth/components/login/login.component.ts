import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Constants } from 'src/app/shared/constants/constants';
import { LoginService } from '../../services/login.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { LoginModel } from '../../models/login.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserType } from 'src/app/shared/enums/user-type.enum';
import { Router } from '@angular/router';
import { RoutePathConfig } from 'src/app/core/config/route-path.config';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  login(){
    this.router.navigate([`/app/superadmin`]);
  }

}
