﻿namespace ToDoApp.Service
{
    public interface IUserService
    {
        Task<bool> Login(string username, string password);

        Task Register(string username, string password);
    }
}
