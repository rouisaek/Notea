using Microsoft.AspNetCore.Identity;

namespace Notea.Api.Extensions;

public static class IdentityErrorExtensions
{
    /// <summary>
    /// Returns a <see cref="Microsoft.AspNetCore.Identity.IdentityError"/> indicating the specified first name is invalid.
    /// </summary>
    /// <param name="firstname">The last name that is invalid.</param>
    /// <returns>
    /// A <see cref="Microsoft.AspNetCore.Identity.IdentityError"/> indicating the specified first name is invalid.
    /// </returns>
    public static IdentityError InvalidFirstName(this IdentityErrorDescriber i, string? firstname) => new IdentityError()
    {
        Code = "InvalidFirstName",
        Description = $"FirstName \'{firstname}\' is invalid."
    };

    /// <summary>
    /// Returns a <see cref="Microsoft.AspNetCore.Identity.IdentityError"/> indicating the specified last name is invalid.
    /// </summary>
    /// <param name="lastname">The last name that is invalid.</param>
    /// <returns>
    /// A <see cref="Microsoft.AspNetCore.Identity.IdentityError"/> indicating the specified last name is invalid.
    /// </returns>
    public static IdentityError InvalidLastName(this IdentityErrorDescriber i, string? lastname) => new IdentityError()
    {
        Code = "InvalidLastName",
        Description = $"Last name '{lastname}' is invalid."
    };

}