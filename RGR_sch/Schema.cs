using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR_sch
{
    class Schema
    {
        public double _v_threshod { get; set; } //порогова напруга
        public double _i_channel { get; set; } //струм у каналі
        public double _v_gate { get; set; }
        public double _v_drain { get; set; }
        public double _v_source { get; set; }
        public double _v_sub { get; set; }
        public double _e0 { get; set; }
        public double _q_e { get; set; } //заряд електрона
        public double _nu { get; set; } //рухомість
        public double _t0 { get; set; } // товщина
        public double f_fermi { get; set; }
        public double _e_sio2 { get; set; }
        public double _e_si { get; set; }
        //results
        public double Na { get; set; }
        public double w_l { get; set; }
        public Schema()
        {
            f_fermi = 0.3;
            _e_sio2 = 3.9;
            _e_si = 11.7;
            _v_threshod = 1.2;
            _i_channel = 0.1;
            _v_gate = 2.5;
            _v_drain = 2.5;
            _v_source = 0;
            _v_sub = 0;
            _e0 = 8.85418782 * Math.Pow(10, -12);
            _q_e = 1.6 * Math.Pow(10, -19);
            _nu = 600 * Math.Pow(10, -4);
            _t0 = Math.Pow(10, -8);
        }

        public double v_na(double Na)
        {
            double v_sb = _v_source - _v_sub;
            double e = _e0 * _e_si;
            double c0x = (_e0 * _e_sio2) / _t0;
            return 2 * f_fermi + Math.Sqrt(2 * _q_e * Na * e * (2 * f_fermi - v_sb)) / c0x;
        }

        public double i_wl(double w_l)
        {
            double c0x = (_e0 * _e_sio2) / _t0;
            double k = c0x * _nu;
            double v_gs = _v_gate - _v_source;
            return (k / 2) * w_l * Math.Pow(v_gs - _v_threshod, 2);
        }

        public double v_t0(double t0)
        {
            double v_sb = _v_source - _v_sub;
            double e = _e0 * _e_si;
            double c0x = (_e0 * _e_sio2) / t0;
            return 2 * f_fermi + Math.Sqrt(2 * _q_e * Na * e * (2 * f_fermi - v_sb)) / c0x;
        }

        public void calculate()
        {
            double e = _e0 * _e_si;
            double c0x = (_e0 * _e_sio2) / _t0;
            double v_sb = _v_source - _v_sub;
            double Na_up = Math.Pow((2 * f_fermi - _v_threshod), 2) * Math.Pow(c0x, 2);
            double Na_down = 2 * _q_e * e * (2 * f_fermi - v_sb);
            Na = Na_up / Na_down;
            //Console.WriteLine("Consentration: " + Na + " for V_threshold = " + _v_threshod);
            double k = c0x * _nu;
            double v_gs = _v_gate - _v_source;
            double w_l_up = 2 * _i_channel;
            double w_l_down = k * Math.Pow(v_gs - _v_threshod, 2);
            w_l = w_l_up / w_l_down;
            //Console.WriteLine("W/L: " + w_l + " for the current " + _i_channel);
        }
    }
}
