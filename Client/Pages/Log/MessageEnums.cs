﻿namespace TKZ.Client.Pages.Log
{
    //Message type
    public enum MessageType
    {
        Success,
        Warning,
        Danger
    }

    //Message Class
    public enum MessageClass
    {
        System,
        IO,
        Nodes,
        Equipment,
        Branches,
        Mutuals,
        Calculation,
        Serialization,
        Deserialization,
        Grid
    }
}