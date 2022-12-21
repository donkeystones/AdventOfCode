const fs = require('fs');

const allCommands = fs.readFileSync('input.txt', 'utf-8');
const interestingCycles = [];
const allCycles = [];

const part1 = () => {
    let register = 1;
    let cycle = 0;

    allCommands.split("\n").forEach(command => {
        let commandArr = command.split(" ");
        if (commandArr[0] == "noop") {
            cycle++;
            allCycles.push({ "cycle": cycle, "register": register })
            if (cycle % 40 == 20) {
                interestingCycles.push({ "cycle": cycle, "register": register, "sum": (cycle * register) });
            }
        }
        else if (commandArr[0] == "addx") {
            cycle++;
            allCycles.push({ "cycle": cycle, "register": register })
            if (cycle % 40 == 20) {
                interestingCycles.push({ "cycle": cycle, "register": register, "sum": (cycle * register) });
                cycle++;
                allCycles.push({ "cycle": cycle, "register": register })
                register += parseInt(commandArr[1]);
            }
            else {
                cycle++;
                allCycles.push({ "cycle": cycle, "register": register })
                if (cycle % 40 == 20) {
                    interestingCycles.push({ "cycle": cycle, "register": register, "sum": (cycle * register) });
                }
                register += parseInt(commandArr[1]);
            }

        }
    })
    console.log(interestingCycles.reduce((n, { sum }) => n + sum, 0)); //Answer part 1
}

const part2 = () => {
    const frame = Array(6)
        .fill()
        .map(() => Array(40).fill(' '));
    let res = "";
    for (let cycle_idx = 1; cycle_idx != allCycles.length; cycle_idx++) {
        const cycle_index = cycle_idx - 1;
        const register = allCycles[cycle_index].register;
        const frame_row = Math.floor(cycle_index / 40);
        const position = cycle_index % 40;
        const in_sprite = position >= register - 1 && position <= register + 1;
        const char = in_sprite ? '█' : ' ';
        frame[frame_row][position] = char;
    }
    const screen = frame.map((r) => r.join('')).join('\n');
    console.log(screen);
}
part1();
part2();