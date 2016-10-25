[![Build status](https://ci.appveyor.com/api/projects/status/g3jejovi6b262u2f?svg=true)](https://ci.appveyor.com/project/matthijsbreemans/postbode)

Example:
```
  using (var postbode = new Postbode())
  {
      postbode.UseMailgun("domain.nl").SetRecipient("to@example.org").SetSender("sender@example.org").SetSubject("test").SetTextContent("HALLLOOOO").SendAsync();
  }
```