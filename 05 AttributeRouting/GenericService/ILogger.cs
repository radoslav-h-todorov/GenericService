﻿namespace GenericService
{
    public interface ILogger
    {
        void Write(string message, params object[] args);
    }
}