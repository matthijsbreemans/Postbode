[![Build status](https://ci.appveyor.com/api/projects/status/g3jejovi6b262u2f?svg=true)](https://ci.appveyor.com/project/matthijsbreemans/postbode) [![Coverage Status](https://coveralls.io/repos/github/matthijsbreemans/Postbode/badge.svg?branch=master)](https://coveralls.io/github/matthijsbreemans/Postbode?branch=master)

Example:
```
  using (var postbode = new Postbode())
  {
      postbode.UseMailgun("domain.nl", "0xapikeyhere").SetRecipient("to@example.org").SetSender("sender@example.org").SetSubject("test").SetTextContent("HALLLOOOO").SendAsync();
  }
```