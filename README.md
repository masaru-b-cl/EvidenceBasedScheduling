EvidenceBasedScheduling
===

This library provides "EBS(Evidence Based Scheduling, see http://www.joelonsoftware.com/items/2007/10/26.html)" simulation results as follows,

- remaining hours
- ship dates
- probability of ship date

## Usage

1. prepare estimates and velocities.

        double[] estimates = ...;
        double[] velocities = ...;
        DateTime[] holidays = ...;

2. create simulator object.


        var simulator = new ShipDateSimulator(estimates, velocities);

3. simulate ship dates (considering holidays).

        var baseDate = DateTime.Parse("2014/1/6");
        DateTime[] shipDates = simulator.Simulate(baseDate, holidays);

4. caluculate "n% ship date" or "probability of ship date".

        var calculator = new ShippingProbabilityCalculator(shipDates);

        // calculate n% ship date
        DateTime shipDate = calculator.CalcShipDate(50.0d);

        // calculate probability of ship date
        double probability = calculator.CalcProbability(DateTime.Parse("2014/3/20"));


## Notice

Current version (0.6) is *very* alpha version. I may cahnge structure (class name, method signature, and others) of this library, in the future.

## License

Copyright 2014 TAKANO Sho.

- http://takanosho.wordpress.com/
- [@masaru\_b\_cl](https://twitter.com/masaru_b_cl)

zlib/libpng

> This software is provided 'as-is', without any express or implied warranty. In no event will the authors be held liable for any damages arising from the use of this software.
> 
> Permission is granted to anyone to use this software for any purpose, including commercial applications, and to alter it and redistribute it freely, subject to the following restrictions:
> 
> 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
> 
> 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
> 
> 3. This notice may not be removed or altered from any source distribution.
> 
> 
> 本ソフトウェアは「現状のまま」で、明示であるか暗黙であるかを問わず、何らの保証もなく提供されます。 本ソフトウェアの使用によって生じるいかなる損害についても、作者は一切の責任を負わないものとします。
> 
> 以下の制限に従う限り、商用アプリケーションを含めて、本ソフトウェアを任意の目的に使用し、自由に改変して再頒布することをすべての人に許可します。
> 
> 1. 本ソフトウェアの出自について虚偽の表示をしてはなりません。あなたがオリジナルのソフトウェアを作成したと主張してはなりません。 あなたが本ソフトウェアを製品内で使用する場合、製品の文書に謝辞を入れていただければ幸いですが、必須ではありません。
> 2. ソースを変更した場合は、そのことを明示しなければなりません。オリジナルのソフトウェアであるという虚偽の表示をしてはなりません。
> 3. ソースの頒布物から、この表示を削除したり、表示の内容を変更したりしてはなりません。