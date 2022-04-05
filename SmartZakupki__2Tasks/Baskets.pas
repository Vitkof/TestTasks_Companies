program Baskets;

{$APPTYPE CONSOLE}
{ (1 2 3 ...N-1)w - sum אנטפל.ןנמדנוס. = P + xd}

uses
  SysUtils;

var
  N,w,d,P,res: integer;
  x:real;

begin
  readln(N);
  readln(w);
  readln(d);
  readln(P);

  x:=((N*(N-1)/2)*w-P) / d;
  res:=round(x);

  if (res>=0) And (res < N) then
  begin
    if res=0 then begin res:=N; end;
    writeln(res);
  end
  else
  begin
    write('Error! ');
    writeln('Check entered parameters.');
  end;

end.
