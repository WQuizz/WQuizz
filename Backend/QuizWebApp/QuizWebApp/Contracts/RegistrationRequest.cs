﻿using System.ComponentModel.DataAnnotations;

namespace QuizWebApp.Contracts;

public record RegistrationRequest(
    [Required]string Email, 
    [Required]string Username, 
    [Required]string Password);
