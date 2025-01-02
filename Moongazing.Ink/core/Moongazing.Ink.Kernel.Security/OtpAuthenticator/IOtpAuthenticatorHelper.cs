namespace Moongazing.Ink.Kernel.Security.OtpAuthenticator;

public interface IOtpAuthenticatorHelper
{
    public Task<byte[]> GenerateSecretKeyAsync();
    public Task<string> ConvertSecretKeyToStringAsync(byte[] secretKey);
    public Task<bool> VerifyCodeAsync(byte[] secretKey, string code); 
}