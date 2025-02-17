﻿using System.ComponentModel.DataAnnotations;

namespace ControlInventario.Core.Models;
public class RegisterRequestModel
{
    [Required]
    public string UserName { get; set;}
    [Required]
    public string Email { get; set;}
    [Required]
    public string UserLogin { get; set;}
    [Required]
    public string Password { get; set;}
}