﻿using static FiapSchoolSystem.Client.SD;

namespace FiapSchoolSystem.Client.Models;

public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object Data { get; set; }
}