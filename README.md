# SnowflakeConverter
Convert discord ID's into human readable date

## How it works?
> Discord snowflake is creation timestamp identifer of something. 
Shift snowflake with **22**, add discord epoch time. Then you'll get **unix milliseconds**.

```csharp
(snowflake >> 22) + 1420070400000 // discord epoch
```
Next parse it and get exact date.

```csharp
DateTimeOffset.FromUnixTimeMilliseconds(unixMS);
```

### Tool
> Paste **snowflake object** and get the **creation timestamp** of it.

[![toolac4829726fec840a.gif](https://s8.gifyu.com/images/toolac4829726fec840a.gif)](https://gifyu.com/image/SHvIS)

> Or, use simplier version with passing params

[![console.gif](https://s8.gifyu.com/images/console.gif)](https://gifyu.com/image/SHvI2)

