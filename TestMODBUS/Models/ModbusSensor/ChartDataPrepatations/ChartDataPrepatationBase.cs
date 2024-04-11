﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestMODBUS.Models.Chart;
using TestMODBUS.Models.Data;

namespace TestMODBUS.Models.ModbusSensor.ChartDataPrepatations
{
    public abstract class ChartDataPrepatationBase
    {
        public virtual double GetNewCurrentPosition(DataStorage DataStorage)
        {
            return DataStorage.GetLastTime();
        }

        public virtual IList<SerieData> GetNewPoints(IList<int> ChannelsToUpdate, DataStorage DataStorage)
        {
            int LastChannel = ChannelsToUpdate.Last();
            double CurrentTime = DataStorage.GetLastTime();
            var WindowDataEdges = WindowingDataHelper.GetDataWindowIndex(CurrentTime, DataStorage.GetChannelData(LastChannel));
            return GetPoints(ChannelsToUpdate, DataStorage, WindowDataEdges.Item1, WindowDataEdges.Item2);
        }

        public virtual IList<SerieData> GetPointsByCurrentX(IList<int> ChannelsToUpdate, DataStorage DataStorage, double CurrentX)
        {
            int LastChannel = ChannelsToUpdate.Last();
            (int, int) WindowDataEdges;
            WindowDataEdges = WindowingDataHelper.GetDataWindowIndex(CurrentX, CurrentX + Chart.MaxWindowWidth, DataStorage.GetChannelData(LastChannel));
            int leftEdge = WindowDataEdges.Item1, rightEdge = WindowDataEdges.Item2;
            return GetPoints(ChannelsToUpdate, DataStorage, leftEdge, rightEdge);
        }

        protected abstract IList<SerieData> GetPoints(IList<int> ChannelsToUpdate, DataStorage DataStorage, int left, int right);

        public abstract IList<string> GetCurrentValues(IList<int> Channels, DataStorage DataStorage);
    }
}
