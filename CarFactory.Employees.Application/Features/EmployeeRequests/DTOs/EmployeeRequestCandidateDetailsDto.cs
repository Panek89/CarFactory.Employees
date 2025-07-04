﻿using CarFactory.Employees.SharedLibrary.Enums;

namespace CarFactory.Employees.Application.Features.EmployeeRequests.DTOs;

public class EmployeeRequestCandidateDetailsDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PersonalId { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public EmployeeCandidateStatus Status { get; init; }
}
