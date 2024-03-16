using WixSharp;

Compiler.BuildMsiCmd(
    new Project("Service Installer")
    {
        GUID = new Guid("2B9BCA25-46BE-48AC-96DF-DDCCBAA8CEB3")
    }
);