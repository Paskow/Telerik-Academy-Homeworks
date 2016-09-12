'use strict';

function solve() {
    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        INVALID_ALIGNMENT_TYPE: 'Alignment must be good, neutral or evil!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    let armyUnitId = 0;

    class Validator {
        static validateName(name) {
            if (name.length < 2 || name.length > 20) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
            if (/[^A-Za-z ]/.test(name)) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
            if (typeof name !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }

        }
    }

    class Spell {
        constructor(name, manaCost, effect) {
            Validator.validateName(name);
            if (manaCost < 1) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
            if (typeof effect !== 'function' || effect.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }

            this._name = name;
            this._manaCost = manaCost;
            this._effect = effect;
        }

        get name() {
            return this._name;
        }

        get manaCost() {
            return this._manaCost
        }

        get effect() {
            return this._effect;
        }

    }

    class Unit {
        constructor(name, alignment) {
            Validator.validateName(name);
            if (alignment !== 'good' && alignment !== 'neutral' & alignment !== 'evil') {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT_TYPE);
            }

            this._name = name;
            this._alignment = alignment;
        }

        get name() {
            return this._name;
        }

        get alignment() {
            return this._alignment;
        }
    }

    class ArmyUnit extends Unit {
        constructor(options) {
            if (options.damage < 0 || options.damage > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
            if (options.health < 0 || options.health > 199) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
            if (options.count < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
            if (options.speed < 0 || options.speed > 99) {
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }

            super(options.name, options.alignment)

            this._id = this._IdGenerator();
            this._damage = options.damage;
            this._health = options.health;
            this._count = options.count;
            this._speed = options.speed;
        }

        get damage() {
            return this._damage;
        }

        get health() {
            return this._health;
        }

        set health(value) {
            this._health = value;
        }

        get count() {
            return this._count;
        }

        set count(value) {
            this._count = value;
        }

        get speed() {
            return this._speed;
        }

        get id() {
            return this._id;
        }

        _IdGenerator() {
            return armyUnitId += 1;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            if (mana < 0 || isNaN(mana)) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }

            super(name, alignment)

            this._mana = mana;
            this._spellbook = [];
            this._army = [];
        }

        get mana() {
            return this._mana;
        }

        set mana(value) {
            this._mana = value;
        }

        get spellbook() {
            return this._spellbook;
        }

        get army() {
            return this._army;
        }
    }


    let _commanders = []
    let _armyUnits = [];
    const battlemanager = {
        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana)
        },

        getArmyUnit(options) {
            let armyUnit = new ArmyUnit(options);
            _armyUnits.push(armyUnit);
            return armyUnit;
        },

        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect)
        },

        addCommanders(...commanders) {
            commanders.forEach((x) => _commanders.push(x));
            return this;
        },

        addArmyUnitTo(commanderName, armyUnit) {
            let commander = _commanders.filter((x) => x.name === commanderName)[0];
            commander.army.push(armyUnit);
            return this;
        },

        addSpellsTo(commanderName, ...spells) {
            let commander = _commanders.filter((x) => x.name === commanderName)[0];
            spells.forEach(function(x) {
                if (!(x instanceof Spell)) {
                    throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }
            })
            commander.spellbook.push(...spells);

            return this;
        },

        findCommanders(query) {
            let result;
            if (query.hasOwnProperty('name') && !query.hasOwnProperty('alignment')) {
                result = _commanders.filter((a) => a.name === query.name);
                return result
            }
            if (query.hasOwnProperty('alignment') && !query.hasOwnProperty('name')) {
                result = _commanders.filter((a) => a.alignment === query.alignment);
                return result;
            }

            return _commanders.filter((a) => a.name === query.name && a.alignment === query.alignment);
        },

        findArmyUnitById(id) {
            return _armyUnits.filter((x) => x.id === id)[0];
        },

        findArmyUnits(query) {
            let result = [];
            let keys = Object.keys(query);

            if (keys.length === 0) {
                return _armyUnits.sort(function(a, b) {
                    if (b.speed - a.speed) {
                        return a.name - b.name
                    }

                    return Number(a.name > b.name) - 0.5
                });
            }

            for (let i = 0; i < _armyUnits.length; i += 1) {
                for (let j = 0; j < keys.length; j += 1) {
                    if (_armyUnits[i][keys[j]] === query[keys[j]]) {
                        if (j === keys.length - 1) {
                            result.push(_armyUnits[i]);
                        } else {
                            continue;
                        }
                    }

                    break;
                }
            }

            return result;
        },

        spellcast(casterName, spellName, targetUnitId) {
            let commander = this.findCommanders({ name: casterName })[0];
            if (commander === undefined) {
                throw new Error('Cannot cast with non-existant commander ' + casterName + '!');
            }
            let spell = commander.spellbook.filter((x) => x.name === spellName)[0];
            if (spell === undefined) {
                throw new Error(casterName + ' does not know ' + spellName);
            }
            let target = this.findArmyUnitById(targetUnitId);
            if (target === undefined) {
                throw new Error('Target not found!');
            }

            if (commander.mana < spell.manaCost) {
                throw new Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
            }
            spell.effect(target);
            commander.mana -= spell.manaCost;

            return this;
        },

        battle(attacker, defender) {
            if (!(attacker instanceof ArmyUnit) || !(defender instanceof ArmyUnit)) {
                throw new Error('Battle participants must be ArmyUnit-like!');
            }
            let attackerDamage = attacker.damage * attacker.count;
            let defenderTotalHealt = defender.health * defender.count;
            let newTotalHealt = defenderTotalHealt - attackerDamage;

            if (defenderTotalHealt > attackerDamage) {
                defender.count = Math.ceil(newTotalHealt / defender.health);
            } else {
                defender.count = 0;
            }

            return this;
        }
    };

    return battlemanager;
}

function test() {

}
module.exports = solve;