program TwoBits;

{$APPTYPE CONSOLE}

uses
  SysUtils;


function Stepen(num,deg: byte):word;
var
    res: word;
    i: byte;
begin
    res := 1;

    i := 0;
    while i < abs(deg) do begin
        res := res * num;
        i := i + 1
    end;

    Stepen:=res;
end;


//Main
var
  num:Word;  {256}
  i,third: byte;
  arr:array [1..16] of byte;  {0,1,1...}

begin
  readln(num);

  i:=0;
  while num > 0 do begin
    if num mod 2 = 1 then
      arr[i]:=1;
    num:=num div 2;
    i:=i+1;
  end;

  for i:=0 to 7 do begin
    third:=arr[i];
    arr[i]:=arr[i+8];
    arr[i+8]:=third;
  end;

  for i:=0 to 15 do begin
    if arr[i]=1 then begin
      num:=num+Stepen(2,i);
    end;
  end;

  writeln(num);
end.

