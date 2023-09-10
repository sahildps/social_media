﻿using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<AppUser>> GetUsersAsync();

    Task<AppUser> GetUserByIdAsync(int id);

    Task<AppUser> GetUsersByUsernameAsync(string username);

    Task<IEnumerable<MemberDto>> GetMembersAsync();

    Task<MemberDto> GetMemberAsync(string username);
    
    // Task AddPhotoAsync(IFormFile file);
}
