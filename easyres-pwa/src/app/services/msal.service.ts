import { Injectable } from '@angular/core';
import * as Msal from 'msal';

@Injectable()
export class MsalService {

    B2CTodoAccessTokenKey = 'b2c.access.token';

    tenantConfig = {
        domain: 'https://EasyRes.b2clogin.com/tfp/',
        tenant: 'EasyRes.onmicrosoft.com',
        // Replace this with your client id
        clientID: '83ed179d-fbb5-41a1-8574-339c976f11c2',
        signInPolicy: 'B2C_1_signin',
        signUpPolicy: 'B2C_1_signup',
        redirectUri: 'https://easyres-pwa.azurewebsites.net',
        b2cScopes: ['https://EasyRes.onmicrosoft.com/access-api/user_impersonation']
    };

    // Configure the authority for Azure AD B2C
    authority = this.tenantConfig.domain + this.tenantConfig.tenant + '/' + this.tenantConfig.signInPolicy;

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
      this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.tenant + '/' + this.tenantConfig.signInPolicy;
      this.authenticate();
    }

    public signup(): void {
      this.clientApplication.authority = this.tenantConfig.domain + this.tenantConfig.tenant + '/' + this.tenantConfig.signUpPolicy;
      this.authenticate();
    }

    public authenticate(): void {
        this.clientApplication.loginPopup(this.tenantConfig.b2cScopes).then(function(idToken: any) {
            this.clientApplication.acquireTokenSilent(this.tenantConfig.b2cScopes).then(
                function(accessToken: any) {
                    this.saveAccessTokenToCache(accessToken);
                }, function(error: any) {
                    this.clientApplication.acquireTokenPopup(this.tenantConfig.b2cScopes).then(
                        function(accessToken: any) {
                            this.saveAccessTokenToCache(accessToken);
                        }, function(error: any) {
                            console.log('error: ', error);
                        });
                });
        }, function(error: any) {
            console.log('error: ', error);
        });
    }

    saveAccessTokenToCache(accessToken: string): void {
        sessionStorage.setItem(this.B2CTodoAccessTokenKey, accessToken);
    }

    logout(): void {
        this.clientApplication.logout();
    }

    isLoggedIn(): boolean {
        return this.clientApplication.getUser() != null;
    }

    getUserEmail(): string {
       return this.getUser().idToken['emails'][0];
    }

    getUser() {
      return this.clientApplication.getUser();
    }

    getUserFirstName() {
        return this.getUser().idToken['given_name'];
    }

    getUserFamilyName() {
        return this.getUser().idToken['family_name'];
    }

    getUserObjectId() {
        return this.getUser().idToken['oid'];
    }
}
