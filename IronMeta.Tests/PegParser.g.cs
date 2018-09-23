//
// IronMeta PegParser Parser; Generated 2018-09-23 11:11:53Z UTC
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

            // AND 0
            int _start_i0 = _index;

            // CALLORVAR Command
            _PegParser_Item _r1;

            _r1 = _MemoCall(_memo, "Command", _index, Command, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label0; }

            // AND 3
            int _start_i3 = _index;

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<string>();
        label4:

            // CALLORVAR WS
            _PegParser_Item _r5;

            _r5 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _PegParser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // CALLORVAR TEXT
            _PegParser_Item _r6;

            _r6 = _MemoCall(_memo, "TEXT", _index, TEXT, null);

            if (_r6 != null) _index = _r6.NextIndex;

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _PegParser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _PegParser_Item(_index, _memo.InputEnumerable)); }

        label0: // AND
            var _r0_2 = _memo.Results.Pop();
            var _r0_1 = _memo.Results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _memo.Results.Push( new _PegParser_Item(_start_i0, _index, _memo.InputEnumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i0;
            }

        }


        public void Command(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // OR 1
            int _start_i1 = _index;

            // LITERAL "SAY"
            _ParseLiteralString(_memo, ref _index, "SAY");

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // LITERAL "ASK"
            _ParseLiteralString(_memo, ref _index, "ASK");

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _PegParser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new string(_IM_Result.Inputs.ToArray()); }, _r0), true) );
            }

        }


        public void TEXT(_PegParser_Memo _memo, int _index, _PegParser_Args _args)
        {

            int _arg_index = 0;
            int _arg_input_index = 0;

            // REGEXP [^{}]+
            _ParseRegexp(_memo, ref _index, _re0);

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _PegParser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new string(_IM_Result.Inputs.ToArray()); }, _r0), true) );
            }

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

