﻿namespace ACV.ConditionReports.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}
