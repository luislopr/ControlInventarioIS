﻿using ControlInventario.WebApi.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ControlInventario.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[HttpClientExceptionFilter]
public abstract class BaseController<T> : ControllerBase
{
    protected readonly T _repositorio;
    public BaseController(T repository) { _repositorio = repository; }
}