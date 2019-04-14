# ef-tutorial

# Deployment
msbuild.exe MyProject.csproj /p:DeployOnBuild=true;PublishProfile=MyProfile

---------------------------------------------------------------------------------
Two TCP ports must be opened to our windows server: 80 and 8172. By default, the Web Deployment Agent Service (MsDepSvc) listens on port 80, and the Web Management Service (WmSvc) listens on port 8172 by default.

To check server availability on these ports open the following links in a web browser:
http://<ip-address>/MSDeployAgentService
https://<ip-address>:8172/msdeploy.axd

We will be asked for login and password. We can login using server Administrator account. In case of connection to 8172 port we will be asked about invalid security self-signed certificate.
---------------------------------------------------------------------------------

1) Install Microsoft Web Deployment tool and add a deployment package to your solution
2) Run MSBuild task with the following Options, specifying the relevant build configuration: "/p:CreatePackageOnPublish=true /p:DeployOnBuild=true /p:Configuration=Release"
3) Capture three artifacts from the build, found under "SolutionDirectory/obj/<BuildConfiguration>/Package/": "ProjectName.deploy.cmd", "ProjectName.SetParameters.xml", "ProjectName.zip"
4) Run the ProjectName.deploy.cmd file from a script task in the deployment project with the following Argument: "/y /m:<remote IIS hostname> /u:<remote admin user on IIS host> /p:<remote user password>"

found all artifacts from build inside Project name \obj\Release\Package folder


# Referencies
https://docs.microsoft.com/en-us/visualstudio/deployment/tutorial-import-publish-settings-iis?view=vs-2019
https://docs.microsoft.com/en-us/iis/install/installing-publishing-technologies/installing-and-configuring-web-deploy-on-iis-80-or-later#configuring-a-site-for-delegated-non-administrator-deployment
https://refactorsaurusrex.com/post/2017/installing-webdeploy/
https://stackoverflow.com/questions/4890289/how-do-i-configure-msbuild-to-use-a-saved-publishprofile-for-webdeploy/8664145#8664145
http://blog.chudinov.net/how-to-prepare-a-windows-server-2012-for-web-deployment/

https://docs.microsoft.com/en-us/iis/publish/using-web-deploy/web-deploy-powershell-cmdlets

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd569058(v=ws.10)
https://community.atlassian.com/t5/Answers-Developer-Questions/How-to-deploy-a-NET-application-on-IIS/qaq-p/498835

https://johanleino.wordpress.com/2013/04/02/using-teamcity-for-asp-net-development-part-3/