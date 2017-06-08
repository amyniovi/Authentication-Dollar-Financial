
Name
----
Dollar.Authentication.Client nuget package


Instructions
--------------------

--------------------------------------------------------------------------------------------------------------
--------------------------------------IMPORTANT---------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
 After installing this package, you will need to:
 Update Microsoft.AspNet.WebApi (via nuget) --(otherwise you will get a mismatch on Newtonsoft.Json assemblies)
---------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------
To use the Authentication Service you need to: 

Call the ResourceIntegrator Login() method to obtain Dollar Authorization :
 
  var apiClient = new ApiClient(Configuration.Load());
  var resourceIntegrator = new ResourceIntegrator(apiClient);
  var response = resourceIntegrator.Login("amy", "password1");

This package will modify your web.config with an additional section as below: 

<configuration>
  <configSections>
    <section name="dollarAuthClient" type="Dollar.Authentication.Client.Configuration, Dollar.Authentication.Client" />
  </configSections>
  <dollarAuthClient
   ResourceId="AccountManagement"
   ServerEndpoint="http://localhost:58179"
   AuthTimeout="4000">
  </dollarAuthClient>
</configuration>

These values can then be modified if needed.


Description
------------
This package hooks up ur application with the Dollar Authentication API Service. 
You will either be authorized or provided with reasons as to why authorization failed.