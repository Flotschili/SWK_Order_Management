﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace OrderManagement.Api.Controllers;

public static class WebApiConventions
{
    // More specific convention must precede general convention.
    // für GET by id
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get(
      [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
    [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.AssignableFrom)] Guid id)
    {
    }

    // für GET all
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
     [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object param)
    {
    }



    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Create(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
     [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object model)
    {
    }

    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Update(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
     [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.AssignableFrom)] Guid id,

    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
     [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object model)
    {
    }

    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Delete(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
     [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.AssignableFrom)] Guid id)
    {
    }
}
