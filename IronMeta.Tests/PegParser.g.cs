//
// IronMeta PegParser Parser; Generated 2018-09-23 11:17:16Z UTC
//

using System;
using System.Collections.Generic;
using System.Linq;

using IronMeta.Matcher;

#pragma warning disable 0219
#pragma warning disable 1591

namespace IronMeta.Tests
{

    using _PegParser_Inputs = IEnumerable<char>;
    using _PegParser_Results = IEnumerable<string>;
    using _PegParser_Item = IronMeta.Matcher.MatchItem<char, string>;
    using _PegParser_Args = IEnumerable<IronMeta.Matcher.MatchItem<char, string>>;
    using _PegParser_Memo = IronMeta.Matcher.MatchState<char, string>;
    using _PegParser_Rule = System.Action<IronMeta.Matcher.MatchState<char, string>, int, IEnumerable<IronMeta.Matcher.MatchItem<char, string>>>;
    using _PegParser_Base = IronMeta.Matcher.Matcher<char, string>;

    public partial class PegParser : Matcher<char, string>
    {
        public PegParser()
            : base()
        {
            _setTerminals();
        }

        public PegParser(bool handle_left_recursion)
            : base(handle_left_recursion)
        {
            _setTerminals();
        }

        void _setTerminals()
        {
            this.Terminals = new HashSet<string>()
            {
                "Command",
                "Expression",
                "TEXT",
                "WS",
            };
        }


        public void Expression(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // AND 1
            int _start_i1 = _index;

            // CALLORVAR Command
            _PegParser_Item _r2;

            _r2 = _MemoCall(_memo, "Command", _index, Command, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // AND 4
            int _start_i4 = _index;

            // PLUS 5
            int _start_i5 = _index;
            var _res5 = Enumerable.Empty<string>();
        label5:

            // CALLORVAR WS
            _PegParser_Item _r6;

            _r6 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r6 != null) _index = _r6.NextIndex;

            // PLUS 5
            var _r5 = _memo.Results.Pop();
            if (_r5 != null)
            {
                _res5 = _res5.Concat(_r5.Results);
                goto label5;
            }
            else
            {
                if (_index > _start_i5)
                    _memo.Results.Push(new _PegParser_Item(_start_i5, _index, _memo.InputEnumerable, _res5.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // CALLORVAR TEXT
            _PegParser_Item _r7;

            _r7 = _MemoCall(_memo, "TEXT", _index, TEXT, null);

            if (_r7 != null) _index = _r7.NextIndex;

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _PegParser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _PegParser_Item(_index, _memo.InputEnumerable)); }

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _PegParser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _PegParser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new string(_IM_Result.Inputs.ToArray()); }, _r0), true) );
            }

        }


        public void Command(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // OR 0
            int _start_i0 = _index;

            // LITERAL "SAY"
            _ParseLiteralString(_memo, ref _index, "SAY");

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL "ASK"
            _ParseLiteralString(_memo, ref _index, "ASK");

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void TEXT(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // REGEXP [^{}]+
            _ParseRegexp(_memo, ref _index, _re0);

        }


        public void WS(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // OR 0
            int _start_i0 = _index;

            // LITERAL ' '
            _ParseLiteralChar(_memo, ref _index, ' ');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL '\t'
            _ParseLiteralChar(_memo, ref _index, '\t');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }

        static readonly Verophyle.Regexp.StringRegexp _re0 = new Verophyle.Regexp.StringRegexp(@"[^{}]+");

    } // class PegParser

} // namespace IronMeta.Tests

