import { Grid2, Typography } from "@mui/material";
import { useFetchCartQuery } from "./cartApi"
import CartItem from "./CartItem";
import OrderSummary from "../../app/shared/components/OrderSummary";

export default function CartPage() {
    const {data, isLoading} = useFetchCartQuery();

    if(isLoading) return <Typography>Loading cart...</Typography>

    if(!data || data.items.length === 0) return <Typography variant="h3">Your cart is empty</Typography>

  return (
    <Grid2 container spacing={2}>
        <Grid2 size={8}>
            {data.items.map(item => (
                <CartItem item={item} key={item.productId} />
            ))}
        </Grid2>
        <Grid2 size={4}>
            <OrderSummary />
        </Grid2>
    </Grid2>
  )
}