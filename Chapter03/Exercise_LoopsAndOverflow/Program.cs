int max = 500;
for (byte i = 0; i < max; i = checked((byte)(i + 1)))
{
    WriteLine(i);
}