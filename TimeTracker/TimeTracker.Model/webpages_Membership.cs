﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model
{
    [Table("webpages_Membership")]
    public class MembershipModel
    {
        [Key, ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ConfirmationToken { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.DateTime> LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public Nullable<System.DateTime> PasswordVerificationTokenExpirationDate { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}