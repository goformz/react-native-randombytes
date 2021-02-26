using Microsoft.ReactNative.Managed;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace Random.Bytes.RNRandomBytes
{
    [ReactModule("RNRandomBytes")]
    class RNRandomBytesModule
    {
        [ReactConstant("seed")]
        public string Seed = getRandomBytes(4096);

        [ReactMethod("randomBytes")]
        public void RandomBytes(uint size, ReactPromise<JSValue> promise)
        {
            promise.Resolve(getRandomBytes(size));
        }

        private static string getRandomBytes(uint size)
        {
            IBuffer buffer = CryptographicBuffer.GenerateRandom(size);
            return CryptographicBuffer.EncodeToHexString(buffer);
        }
    }
}