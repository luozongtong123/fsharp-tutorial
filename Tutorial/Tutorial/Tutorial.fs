open System                        // 这步操作可以让我们使用 .NET Core 的函数库

let hello() =                      // let 用来绑定函数名或者参数名
  printf "Enter your name: "     // printf 不启用新行的打印函数
    
  let name = Console.ReadLine()  // 读取一行并将读取到的值和 name 绑定

  printfn "Hello %s!" name       // 启用新行的打印 % 引用参数
  // %s %i %f %b %A %O           

hello()

let hello1() =
  printfn "PI: %f" 3.14159265358979323846264338327       // 浮点数只有6位小数
  printfn "PI: %.4f" 3.14159265358979323846264338327     // 可以调整显示的小数的位数
  printfn "Big PI: %M" 3.14159265358979323846264338327M  // 最高可以到达27位小数

hello1()

let hello2() =
  printfn "%-5s %5s" "a" "b"             // 添加空格
  printfn "%*s" 10 "Hi"                  // 动态空格
    
hello2()

let bindStuff() =
  let mutable weight = 175         // 可以改变的参数 (mutable)
  weight <- 170                    // 使用 <- 赋值
  
  printfn "Weight: %i" weight

  let changeMe = ref 10            // 奇怪的语法，先不管这了
  changeMe := 50

  printfn "Change: %i" ! changeMe

bindStuff()

let doFuns() =
  let getSum(x : int, y : int) :int = x + y

  printfn "5 + 7 = %i" (getSum(5,7))

  // 递归函数
  let rec factorial x =
    if x < 1 then 1
    else x * factorial (x - 1)
  
  printfn "Factorial 4 : %i" (factorial 4)
  // 1st : result = 4 * factoral(3) = 4 * 6 = 24
  // 2st : result = 3 * factoral(2) = 3 * 2 = 6
  // 1st : result = 2 * factoral(1) = 2 * 1 = 2

  // 定义一个列表 (List)
  let randList = [1; 2; 3]
  // map 可以对数组里的每一个元素进行特定操作，
  // 第一个参数是 lambda 表达式 (anonymous function, 匿名函数)
  // 第二个参数是被操作的数组
  let randList2 =  List.map (fun x -> x * 2) randList
  printfn "Double List : %A" randList2

  // 管道可以很方便地进行多步计算
  // 管道：将值输入(|>)到函数中
  [5; 6; 7; 8]
  |> List.filter (fun v -> (v % 2) = 0)
  |> List.map (fun x -> x * 2)
  |> printfn "Even Doubles %A" 

  // >> 和 << 可以将两个函数合二为一
  let multNum x = x * 3
  let addNum y = y + 5

  let multAdd = multNum >> addNum
  let addMult = multNum << addNum

  printfn "multAdd : %i" (multAdd 10)
  printfn "addMult : %i" (addMult 10)

doFuns()

// 一些数学函数
let doMath() =
  printfn "5 + 4 = %i" (5 + 4)
  printfn "5 - 4 = %i" (5 - 4)
  printfn "5 * 4 = %i" (5 * 4)
  printfn "5 / 4 = %i" (5 / 4)
  // "" 里面用 % 要用 %%
  printfn "5 %% 4 = %i" (5 % 4)
  // 5^2
  printfn "5 ** 2 = %f" (5.0 ** 2.0)

  let number = 2
  printfn "Type: %A" (number.GetType())
  printfn "A Float: %.2f" (float number)
  printfn "An Int: %i" (int 3.14)

  // 其他数学函数
  // 绝对值
  printfn "abs 4.5 : %i" (abs -1)
  // 向上取整
  printfn "ceil 4.5 : %f" (ceil 4.5)
  // 向下取整
  printfn "floor 4.5 : %f" (floor 4.5)
  // ln
  printfn "log 2.71828 : %f" (log 2.71828)
  // lg
  printfn "log10 1000 : %F" (log10 1000.0)
  // 求平方根
  printfn "sqrt 25 : %f" (sqrt 25.0)


doMath()

let stringStuff() =
  let str1 = "This is a random string\\"
  // @ 加到字符串之前可以将 \ 加入到字符串之中
  let str2 = @"I ignore backslashes\\\\"
  // 三个双引号可将引号添加到字符串
  let str3 = """ "I ignore qutes and backslashes" """
  // 字符串相连
  let str4 = str1 + " " + str2
  // length 获取字符串的长度
  printfn "Length : %i" (String.length str4)
  // 和 C 相似的字符访问
  printfn "%c" str1.[1]
  // 和 Python 相似的字符串切片操作
  printfn "First word : %s" (str1.[..3])
  printfn "Second word : %s" (str1.[5..6])
  printfn "The rest word : %s" (str1.[8..])

  // 
  let upperStr = String.collect (fun c -> sprintf "%c, " c) "commas"
  printfn "Commas : %s" upperStr

  // 测试字符串中是否有字符满足条件
  printfn "Any upper: %b" (String.exists (fun c -> Char.IsUpper c) str1)

  // 测试字符串中所有的字符满足条件
  printfn "Number : %b" (String.forall (fun c -> Char.IsDigit c) "1234")

  // 初始化字符串
  let string1 = String.init 10 (fun i -> i.ToString() )
  printfn "Numbers : %s" string1

  // 对字符串中的每个字符进行操作
  String.iter (fun c -> printfn "%c" c) "Print Me!"

stringStuff()

let loopStuffWhile() =
  let magic_num = "7"
  let mutable guess = ""

  while not (magic_num.Equals(guess)) do
    printf "Guess the Number :"
    guess <- Console.ReadLine()

  printfn "You Guessed the Number!"

loopStuffWhile()

let loopStuffFor() = 
  for i = 1 to 10 do 
    printfn "%i" i

  for i = 10 downto 1 do
    printfn "%i" i

  for i in [1..10] do
    printfn "%i" i

  [1..10] |> List.iter (printfn "Num : %i")

  let sum = List.reduce (+) [1..10]
  printfn "Sum : %i" sum

loopStuffFor()

Console.ReadKey() |> ignore        // 输入一个字符，防止命令行一闪而过
