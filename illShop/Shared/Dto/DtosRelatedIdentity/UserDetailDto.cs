﻿namespace illShop.Shared.Dto.DtosRelatedIdentity
{
    public class UserDetailDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool EmailConfimed { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfimed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public long AccessFaildCount { get; set; }

    }
}
