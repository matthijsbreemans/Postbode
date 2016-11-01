[![Build status](https://ci.appveyor.com/api/projects/status/g3jejovi6b262u2f?svg=true)](https://ci.appveyor.com/project/matthijsbreemans/postbode) [![codecov](https://codecov.io/gh/matthijsbreemans/Postbode/branch/master/graph/badge.svg)](https://codecov.io/gh/matthijsbreemans/Postbode)


Example:
```
  using (var postbode = new Postbode())
  {
      postbode.UseMailgun("domain.nl", "0xapikeyhere").SetRecipient("to@example.org").SetSender("sender@example.org").SetSubject("test").SetTextContent("HALLLOOOO").SendAsync();
  }
```