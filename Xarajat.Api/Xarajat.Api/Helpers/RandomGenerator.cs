﻿
namespace Xarajat.Api.Helpers;

public static class RandomGenerator
{
    public static string GetRandomString() =>Guid.NewGuid().ToString("N").Substring(0,10);
}
