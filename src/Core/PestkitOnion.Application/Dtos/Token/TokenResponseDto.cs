﻿namespace PestkitOnion.Application.Dtos.Token
{
    public record TokenResponseDto(string Token, DateTime ExpireTime, string UserName);
}
