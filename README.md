# Three Step Web Login App

Base on Chrome Driver and .NET console to automatic login with three steps. Normally on the login page, it's need account, password, and submit button. We need three steps to login like below:

1. Enter account
2. Enter password
3. Click Submit button

## Setting File

All settings are store in `appsettings.json` file.

```json
{
    "url": "http://YOUR_THREE_STEP_WEB_LOGIN_SITE/",
    "delayClose": 5,
    "delayRedirect": 3,
    "hideWindow": false,
    "loginInfo": {
        "account": "YOUR_ACCOUNT",
        "password": "YOUR_PASSWORD"
    },
    "stepXpath": {
        "step1": "/html/body/table[4]/tbody/tr[2]/td/table/tbody/tr/td[1]/form/p[1]/input",
        "step2": "/html/body/table[4]/tbody/tr[2]/td/table/tbody/tr/td[1]/form/p[2]/input",
        "step3": "/html/body/table[4]/tbody/tr[2]/td/table/tbody/tr/td[1]/form/p[3]/input[1]"
    }
}
```

- `url`: It is the login page URL.
- `delayClose`: It is for delay after finish the process. Let us has more time to understand what's happened.
- `delayRedirect`: It is for delay after redirect to `www.google.com`. If redirect is success, it's mean you can surf internet freely.
- `hideWindow`: Show the Chrome window or not.
- `loginInfo`: Login account and password.
- `stepXpath`: Use XPath to indicate the input fields and where is submit button.
