import { Injectable } from '@angular/core';
import * as Msal from 'msal';
import { UserService } from './user.service';

@Injectable()
export class MsalService {

    constructor(private userService: UserService) {}

    B2CTodoAccessTokenKey = 'b2c.access.token';

    tenantConfig = {
        domain: 'https://EasyRes.b2clogin.com/tfp/EasyRes.onmicrosoft.com/',
        // Replace this with your client id
        clientID: '83ed179d-fbb5-41a1-8574-339c976f11c2',
        signInPolicy: 'B2C_1_signin',
        signUpPolicy: 'B2C_1_signup',
        resetPasswordPolicy: 'B2C_1_resetpassword',
        editProfilePolicy: 'B2C_1_editprofile',
        redirectUri: 'https://easyres-pwa.azurewebsites.net',
        b2cScopes: ['https://EasyRes.onmicrosoft.com/access-api/user_impersonation']
    };

    // Configure the authority for Azure AD B2C
    authority = this.tenantConfig.domain + this.tenantConfig.signInPolicy;

    /*
     * B2C SignIn SignUp Policy Configuration
     */
    clientApplication = new Msal.UserAgentApplication(
        this.tenantConfig.clientID, this.authority,
        function(errorDesc: any, token: any, error: any, tokenType: any) {
        },
        {
          validateAuthority: false
        }
    );

    public login(): void {
      this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.signInPolicy;
      this.authenticate();
    }

    public signup(): void {
      this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.signUpPolicy;
      this.authenticate();
    }

    public resetPassword(): void {
        this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.resetPasswordPolicy;
        this.authenticate();
    }

    public editProfile(): void {
        this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.editProfilePolicy;
        this.authenticate();
    }

    public authenticate(): void {
        const THIS = this;
        this.clientApplication.loginPopup(this.tenantConfig.b2cScopes).then(function(idToken: any) {
            THIS.clientApplication.acquireTokenSilent(THIS.tenantConfig.b2cScopes).then(
                function(accessToken: any) {
                    THIS.saveAccessTokenToCache(accessToken);
                }, function(error: any) {
                    THIS.clientApplication.acquireTokenPopup(THIS.tenantConfig.b2cScopes).then(
                        function(accessToken: any) {
                            THIS.saveAccessTokenToCache(accessToken);
                        }, function(error: any) {
                            console.log('error: ', error);
                        });
                });
        }, function(errorDesc: any) {
            console.log('error: ', errorDesc);
            if (errorDesc.indexOf('AADB2C90118') > -1) {
                THIS.resetPassword();
            } else if (errorDesc.indexOf('AADB2C90077') > -1) {
                // Expired Token
                THIS.logout();
            }
        });
    }

    saveAccessTokenToCache(accessToken: string): void {
        sessionStorage.setItem(this.B2CTodoAccessTokenKey, accessToken);
        if (this.isNew()) {
            this.userService.saveUserInDb(this.getUserObjectId()).subscribe();
        }
    }

    logout(): void {
        this.clientApplication.logout();
    }

    getUser() {
        return this.clientApplication.getUser();
    }

    isLoggedIn(): boolean {
        return this.getUser() != null;
    }

    isNew() {
        if (this.getUser().idToken['newUser']) {
            return true;
        }
        return false;
    }

    getUserObjectId() {
        return this.getUser().idToken['oid'];
    }

    getUserFirstName() {
        return this.getUser().idToken['given_name'];
    }

    getUserFamilyName() {
        return this.getUser().idToken['family_name'];
    }

    getUserEmail(): string {
        return this.getUser().idToken['emails'][0];
    }
}
